using WaterJugASP.Models;

namespace WaterJugASP.Utils
{
    enum MainJug
    {
        X,
        Y
    }

    public static class WaterJugSolver
    {
        private static List<WaterJugModel> _steps = new();

        public static List<WaterJugModel> State { get => _steps; }

        /// <summary>
        /// Check if the given input is a valid input for the Water Jug problem.
        /// </summary>
        /// <param name="input">The values for X, Y and Z</param>
        /// <returns>true if the input is valid, false otherwise.</returns>
        public static bool CanSolve(WaterJugModel input)
        {
            if (input.Z > input.X && input.Z > input.Y)
            {
                return false; //If z is greater than both x and y, then there is no solution
            }
            else if (input.X % 2 == 0 && input.Y % 2 == 0 && input.Z % 2 != 0)
            {
                return false; //If x and y are even and z is odd, then there is no solution
            }

            return true;
        }

        /// <summary>
        /// Tries to find the solution for the given input.
        /// </summary>
        /// <param name="input">The values to use in the Water Jug problem</param>
        /// <returns>The solution if it exists, null otherwise.</returns>
        public static List<WaterJugModel>? FindSolution(WaterJugModel input)
        {
            List<WaterJugModel> xSteps = new(), ySteps = new();

            //Run the solve function for both x and y as the main jug
            var solFoundX = Solve(0, 0, input, MainJug.X, xSteps, new());
            var solFoundY = Solve(0, 0, input, MainJug.Y, ySteps, new());

            if (!solFoundX && !solFoundY)
            {
                return null;
            } else if (solFoundX && !solFoundY)
            {
                _steps = xSteps;
                return _steps;
            } else if (!solFoundX && solFoundY)
            {
                _steps = ySteps;
                return _steps;
            } else if (xSteps.Count < ySteps.Count)
            {
                _steps = xSteps;
                return _steps;
            } else
            {
                _steps = ySteps;
                return _steps;
            }
        }

        /// <summary>
        /// Recursive function that solves the Water Jug problem.
        /// </summary>
        /// <param name="x">The current amount of water in the first jug</param>
        /// <param name="y">The current amount of water in the second jug</param>
        /// <param name="input">The values to use in the Water Jug problem</param>
        /// <param name="mainJug">The main jug to use for the next iteration</param>
        /// <param name="steps">The steps that have been taken so far</param>
        private static bool Solve(int x, int y, WaterJugModel input, MainJug mainJug, List<WaterJugModel> steps, HashSet<KeyValuePair<int, int>> visited)
        {
            //If we have reached the goal, return
            if (x == input.Z || y == input.Z)
            {
                steps.Add(new() { X = x, Y = y, Z = input.Z }); //Add the current state to the steps array
                return true;
            }

            if (!visited.Contains(new(x, y)))
            {
                steps.Add(new() { X = x, Y = y, Z = input.Z });
                visited.Add(new(x, y));

                //If the main jug is x, then we need to try to fill it up first
                if (mainJug == MainJug.X)
                {
                    //Empty y if it's full
                    if (y == input.Y)
                    {
                        return Solve(x, 0, input, mainJug, steps, visited);
                    }
                    else if (x == 0)
                    { //Fill x if it's empty
                        return Solve(input.X, y, input, mainJug, steps, visited);
                    }
                    else
                    { //Transfer water from x to y
                        int remSpace = input.Y - y;
                        int pouredWater = x > remSpace ? remSpace : x;

                        return Solve(x - pouredWater, y + pouredWater, input, mainJug, steps, visited);
                    }
                }
                else
                { //If the main jug is y, then we need to try to fill it up first
                    if (x == input.X)
                    {
                        return Solve(0, y, input, mainJug, steps, visited);
                    }
                    else if (y == 0)
                    {
                        return Solve(x, input.Y, input, mainJug, steps, visited);
                    }
                    else
                    {
                        int remSpace = input.X - x;
                        int pouredWater = y > remSpace ? remSpace : y;

                        return Solve(x + pouredWater, y - pouredWater, input, mainJug, steps, visited);
                    }
                }
            }

            return false;
        }
    }
}
