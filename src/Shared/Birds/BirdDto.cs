using FluentValidation;

namespace Shared.Birds;

public class BirdDto
{
    public class Index
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public int AmountOfSpots { get; set; }
    }

    public class Spot
    {
        public int BirdId { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string? Spotter { get; set; }
        public string? Remark { get; set; }
        public DateTime SpottedOn { get; set; } = DateTime.Now;

        public class Validator : AbstractValidator<Spot>
        {
            public Validator()
            {
                RuleFor(s => s.BirdId).NotEmpty();
                RuleFor(s => s.Longitude).NotEmpty();
                RuleFor(s => s.Latitude).NotEmpty();
                RuleFor(s => s.SpottedOn)
                    .NotEmpty()
                    .InclusiveBetween(DateTime.Now.AddYears(-1), DateTime.Now);
            }
        }
    }

}
