using StateTaskSystem.State.Enum;

namespace StateTaskSystem.State
{
    public class StateTaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StateTask State { get; set; }
    }
}
