namespace Learning.inheritance.TablePerType
{
    public partial class Snake : Animal
    {
        public virtual bool? IsVenomous { get; set; }
        public virtual  decimal? Length { get; set; }
    }
}
