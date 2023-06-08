﻿using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Model;

namespace Domain;

public class ParticipationDomain : IParticipationDomain
{
    private readonly IParticipationInfrastructure _participationInfrastructure;

    public ParticipationDomain(IParticipationInfrastructure participationInfrastructure)
    {
        _participationInfrastructure = participationInfrastructure;
    }

    public List<Participation> GetAll()
    {
        return _participationInfrastructure.GetAll();
    }

    public Participation GetById(int id)
    {
        return _participationInfrastructure.GetById(id);
    }

    public bool Create(Participation participationData)
    {
        return _participationInfrastructure.Create(participationData);
    }

    public bool Update(int id, Participation participationData)
    {
        return _participationInfrastructure.Update(id, participationData);
    }

    public bool Delete(int id)
    {
        return _participationInfrastructure.Delete(id);
    }
}