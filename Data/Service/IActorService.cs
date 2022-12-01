﻿using System;
using ETickets.Models;

namespace ETickets.Data.Service
{
    public interface IActorService
    {

        Task<IEnumerable<Actor>> GetActors();

        Task<Actor> GetActor(int id);

        Task AddActor(Actor actor);


        Task<Actor> UpdateActor(int id, Actor actor);


       Task DeleteActor(int id);


    }
}

