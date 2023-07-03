using FluentValidation;

namespace WaterJugASP.Models
{
    public class WaterJugModel
    {
        /// <summary>
        /// The max ammount of water in the first jug
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The max ammount of water in the second jug
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The target
        /// </summary>
        public int Z { get; set; }
    }

    public class WaterJugModelValidator : AbstractValidator<WaterJugModel>
    {
        public WaterJugModelValidator()
        {
            RuleFor(wj => wj.X).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(wj => wj.Y).NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(wj => wj.Z).NotEmpty().GreaterThanOrEqualTo(1);
        }
    }
}
