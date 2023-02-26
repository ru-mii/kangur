namespace kangur
{
    public struct PointersData
    {
        public uint GameletPointer { get; private set; }
        public uint HeroPointer { get; private set; }
        public uint PositionPointer { get; private set; }

        public PointersData(uint gameletPointer)
        {
            GameletPointer = gameletPointer;
            HeroPointer = Toolkit.ReadMemoryInt32(GameletPointer + 0x38C);
            PositionPointer = Toolkit.ReadMemoryInt32(GameletPointer + 0x38C) + 0x50;
        }
    }
}
