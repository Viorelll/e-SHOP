namespace Factory
{
    using DomainModel.Interfaces;
    public class MakeGift
    {
        public void PrepareGift(IItemComponent itemComponent)
        {
            itemComponent.AddGift();
        }
    }
}
