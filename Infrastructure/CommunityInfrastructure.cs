﻿using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CommunityInfrastructure : ICommunityInfrastructure
{
    private readonly UpdateDbContext _updateDbContext;
    
    public CommunityInfrastructure(UpdateDbContext updateDbContext)
    {
        _updateDbContext = updateDbContext;
    }

    public async Task<List<Community>> GetAll()
    {
        return await _updateDbContext.Communities.Where(community => community.IsActive).ToListAsync();
    }

    public async Task<Community> GetById(int id)
    {
        return await _updateDbContext.Communities.SingleAsync(community => community.IsActive && community.Id == id);
    }

    public async Task<bool> Create(Community communityData)
    {
        try
        {
            communityData.IsActive = true;
            await _updateDbContext.Communities.AddAsync(communityData);
            await _updateDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Update(int id, Community communityData)
    {
        try
        {
            var community = await _updateDbContext.Communities.FindAsync(id);

            community.Name = communityData.Name;
            community.Description = communityData.Description;

            _updateDbContext.Communities.Update(community);
            await _updateDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        var community = await _updateDbContext.Communities.FindAsync(id);
        community.IsActive = false;

        _updateDbContext.Communities.Update(community);
        await _updateDbContext.SaveChangesAsync();
        
        return true;
    }
}