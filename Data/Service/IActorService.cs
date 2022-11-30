using System;
using ETickets.Models;

namespace ETickets.Data.Service
{
    public interface IActorService
    {

        Task<IEnumerable<Actor>> GetActors();

        Actor GetActor(int id);

        void AddActor(Actor actor);


        Actor UpdateActor(int id, Actor actor);


        void DeleteActor(int id);


    }
}

