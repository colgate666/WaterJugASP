using WaterJugASP.Models;
using WaterJugASP.Utils;

namespace WaterJugASP.Handlers
{
    public class WaterJugHandler
    {
        /// <summary>
        /// The post endpoint runs the water jug problem solver for a given input
        /// </summary>
        /// <param name="input">Values for X, Y and Z to be used in the water jug problem</param>
        /// <returns>The solution, if there's one</returns>
        public IResult HandlePost(WaterJugModel input)
        {
            if (input.X <= 0 || input.Y <= 0 || input.Z <= 0)
            {
                return Results.BadRequest(new { Message = "Invalid request body" });
            }

            if (!WaterJugSolver.CanSolve(input))
            {
                return Results.Ok(new { Message = "No solution" });
            }

            var result = WaterJugSolver.FindSolution(input);

            if (result == null)
            {
                return Results.Ok(new { Message = "No solution" });
            }

            return Results.Ok(result);
        }

        /// <summary>
        /// The Get endpoint returns the steps taken to resolve the last processed water jug problem.
        /// </summary>
        /// <returns>The list of steps taken</returns>
        public IResult HandleGet()
        {
            return Results.Ok(WaterJugSolver.State);
        }
    }
}
