using System;
using System.Numerics;

namespace kangur
{
    public class Hero
    {
        public Vector3 HeroPosition
        { 
            get
            {
                uint heroPointer = Main.MainWindow.PointersData.HeroPointer;

                float posX = Toolkit.ReadMemoryFloat(heroPointer + 0x58);
                float posY = Toolkit.ReadMemoryFloat(heroPointer + 0x5C);
                float posZ = Toolkit.ReadMemoryFloat(heroPointer + 0x60);

                _playerPosition = new Vector3(posX, posY, posZ);
                return _playerPosition;
            }
            set
            {
                _playerPosition = value;
            }
        }

        private Vector3 _playerPosition;

        public Vector2 HeroRotation
        {
            get
            {
                uint heroPointer = Main.MainWindow.PointersData.HeroPointer;

                float rotX = Toolkit.ReadMemoryFloat(heroPointer + 0x50);
                float rotY = Toolkit.ReadMemoryFloat(heroPointer + 0x54);

                _playerRotation = new Vector2(rotX, rotY);
                return _playerRotation;
            }
            set
            {
                _playerRotation = value;
            }
        }
        private Vector2 _playerRotation;

        public void SaveHeroTransformToMemory()
        {
            // convert to byte array for faster writings and single execution style
            byte[] rotX = BitConverter.GetBytes(_playerRotation.X);
            byte[] rotY = BitConverter.GetBytes(_playerRotation.Y);
            byte[] posX = BitConverter.GetBytes(_playerPosition.X);
            byte[] posY = BitConverter.GetBytes(_playerPosition.Y);
            byte[] posZ = BitConverter.GetBytes(_playerPosition.Z);

            // merge byte arrays
            byte[] fullByteTable = Toolkit.MergeByteArrays(rotX, rotY, posX, posY, posZ);

            // write full vector5 position as byte arary
            Toolkit.WriteMemory(Main.MainWindow.PointersData.PositionPointer, fullByteTable);
        }

    }
}
