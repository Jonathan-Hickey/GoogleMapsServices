namespace GoogleMapsServices.Client
{
    public sealed class Field
    {
        private readonly string _field;

        private static readonly Dictionary<string, Field> FieldLookUp = new Dictionary<string, Field>
        {
            {"formatted_address", Fields.FormattedAddress},
            {"name", Fields.Name},
            {"rating", Fields.Rating},
            {"opening_hours", Fields.OpeningHours},
            {"geometry", Fields.Geometry},
        };

        public Field(string field)
        {
            _field = field;
        }

        public string Value()
        {
            return _field;
        }
        
        public override int GetHashCode()
        {
            return _field.GetHashCode();
        }

        private static bool Equals(Field? fieldOne, Field? fieldTwo)
        {
            if (fieldOne is null && fieldTwo is null) return true;
            if (fieldOne is null != fieldTwo is null) return false;

            return string.Equals(fieldOne.Value(), fieldTwo.Value());
        }

        public override bool Equals(object? obj)
        {
            if (obj is Field field) return Equals(this, field);

            return false;
        }

        public override string ToString()
        {
            return _field;
        }

        public static Field? Parse(string? input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            if(TryParse(input, out Field? field))
            {
                return field;
            }

            throw new FieldDoesNotExistException(string.Format("Invalid field value {input}", input));
        }

        public static bool TryParse(string input, out Field? field)
        {
            if (string.IsNullOrEmpty(input))
            {
                field = null;
                return false;
            }

            var key = input.ToLowerInvariant();
            if (FieldLookUp.ContainsKey(key))
            {
                field = FieldLookUp[key];
                return true;
            }

            field = null;
            return false;
        }

        public static explicit operator Field?(string? input)
        {
            return Parse(input);
        }

        public static bool operator ==(Field? fieldOne, Field fieldTwo)
        {
            return Equals(fieldOne, fieldTwo);
        }

        public static bool operator !=(Field? fieldOne, Field fieldTwo)
        {
            return !Equals(fieldOne, fieldTwo);
        }
    }
}
