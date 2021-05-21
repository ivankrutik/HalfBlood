namespace Learning.inheritance
{
    public partial class Snake : Animal
    {
        public virtual decimal? Length { get; set; }
        public virtual  string IsVenomous { get; set; }
    }
}
