namespace Learning.inheritance.TablePerType
{
    public partial class Horse : Animal
    {
        public virtual string Breed { get; set; }
        public virtual decimal? MaximumSpeed { get; set; }

    }
}