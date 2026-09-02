namespace Assignment1
{
    public class Spaceship
    {
        public string Name { get; }
        public int Size { get; }

        private Stack<Cargo> _storage = new Stack<Cargo>();
        private int _freeCargoSpace;

        public Spaceship(string name, int size)
        {
            Name = name;
            Size = size;
            _freeCargoSpace = size;
        }

        public bool AddCargo(Cargo item)
        {
            if (_freeCargoSpace < item.Size)
            {
                return false;
            }

            _storage.Push(item);
            _freeCargoSpace -= item.Size;
            return true;
        }

        public Cargo? RemoveCargo()
        {
            if (_storage.Count == 0)
            {
                return null;
            }
            var cargo = _storage.Pop();
            _freeCargoSpace += cargo.Size;
            return cargo;
        }

        public void ListCargo()
        {
            if (_storage.Count == 0)
            {
                Console.WriteLine("<empty>");
            }

            foreach (var cargo in _storage)
            {
                Console.WriteLine($" * {cargo.Description}");
            }
        }

        public bool MoveCargoTo(Spaceship spaceship)
        {
            Cargo? cargo;
            while ((cargo = RemoveCargo()) != null)
            {
                if (spaceship.AddCargo(cargo))
                {
                    continue;
                }

                AddCargo(cargo);
                return false;
            }

            return true;
        }
    }
}
