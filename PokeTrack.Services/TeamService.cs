using PokeTrack.Data;
using PokeTrack.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeTrack.Services
{
    public class TeamService
    {
        /// <summary>
        /// Creates new Team
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool CreateTeam(TeamCreate model)
        {
            var entity =
                 new Team()
                 {
                     TeamName = model.TeamName,
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TeamDb.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Retieves all instances of Team
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamDb
                        .Where(e => e.TeamID == e.TeamID)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamID = e.TeamID,
                                    TeamName = e.TeamName,
                                    PokemonTeam = e.PokemonTeam.ToList()
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves specified Team using the assigned TeamID
        /// </summary>
        /// <returns>array</returns>
        public IEnumerable<TeamListItem> GetTeamByID(int teamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamDb
                        .Where(e => e.TeamID == teamID)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamID = e.TeamID,
                                    TeamName = e.TeamName,
                                    PokemonTeam = e.PokemonTeam.ToList()
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Retrieves specified Team using the assigned TeamName
        /// </summary>
        /// <param name="teamName"></param>
        /// <returns>array</returns>
        public IEnumerable<TeamListItem> GetTeamByTeamName(string teamName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TeamDb
                        .Where(e => e.TeamName == teamName)
                        .Select(
                            e =>
                                new TeamListItem
                                {
                                    TeamID = e.TeamID,
                                    TeamName = e.TeamName,
                                    PokemonTeam = e.PokemonTeam.ToList()
                                }
                        );

                return query.ToArray();
            }
        }

        /// <summary>
        /// Allows Application User to edit Team properties individually
        /// </summary>
        /// <param name="model"></param>
        /// <returns>bool</returns>
        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeamDb
                    .Single(e => e.TeamID == model.TeamID);
                entity.TeamName = model.TeamName;

                return ctx.SaveChanges() == 1;
            }
        }

        /// <summary>
        /// Deletes spcified Team using its assigned TeamID
        /// </summary>
        /// <param name="teamID"></param>
        /// <returns>bool</returns>
        public bool DeleteTeam(int teamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .TeamDb
                    .Single(e => e.TeamID == teamID);

                ctx.TeamDb.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
