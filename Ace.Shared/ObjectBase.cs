namespace Ace.Shared
{
    public abstract class ObjectBase
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime modifyDate { get; set; } = DateTime.Now;
    }
}
