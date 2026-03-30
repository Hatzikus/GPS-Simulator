namespace GPS_Bluetooth
{
	public class fixType
	{
		public int Value { get; private set; }
		public string Description { get; private set; }

		public fixType(int value, string description)
		{
			Value = value;
			Description = description;
		}

		public override string ToString()
		{
			return Description;
		}
	}
}
