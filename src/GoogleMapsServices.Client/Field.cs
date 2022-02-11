namespace GoogleMapsServices.Client
{
    /// Fields are divided into three billing categories: Basic, Contact, and Atmosphere. Basic fields are billed at base rate, and incur no additional charges. Contact and Atmosphere fields are billed at a higher rate. See the [pricing sheet](https://cloud.google.com/maps-platform/pricing/sheet/) for more information. Attributions, `html_attributions`, are always returned with every call, regardless of whether the field has been requested.
    /// 
    /// **Basic**
    /// 
    /// The Basic category includes the following fields: `address_component`, `adr_address`, `business_status`, `formatted_address`, `geometry`, `icon`, `icon_mask_base_uri`, `icon_background_color`, `name`, `permanently_closed` ([deprecated](https://developers.google.com/maps/deprecations)), `photo`, `place_id`, `plus_code`, `type`, `url`, `utc_offset`, `vicinity`.
    /// 
    /// **Contact**
    /// 
    /// The Contact category includes the following fields: `formatted_phone_number`, `international_phone_number`, `opening_hours`, `website`
    /// 
    /// **Atmosphere**
    /// 
    /// The Atmosphere category includes the following fields: `price_level`, `rating`, `review`, `user_ratings_total`.</param>
    public sealed class Field
    {
        private static readonly Dictionary<string, Field> FieldLookUp = new Dictionary<string, Field>
        {
            //Basic
            {"address_component", Basic.AddressComponent},
            {"adr_address", Basic.AdrAddress},
            {"business_status", Basic.Geometry},
            {"formatted_address", Basic.FormattedAddress},
            {"geometry", Basic.Geometry},
            {"icon", Basic.Icon},
            {"icon_mask_base_uri", Basic.IconMaskBaseUri},
            {"icon_background_color", Basic.IconBackgroundColor},
            {"name", Basic.Name},
            {"photo", Basic.Photo},
            {"place_id", Basic.PlaceId},
            {"plus_code", Basic.PlusCode},
            {"type", Basic.Type},
            {"url", Basic.Url},
            {"utc_offset", Basic.UtcOffset},
            {"vicinity", Basic.Vicinity},

            //Contact
            {"formatted_phone_number", Contact.FormattedPhoneNumber},
            {"international_phone_number", Contact.InternationalPhoneNumber},
            {"opening_hours", Contact.OpeningHours},
            {"website", Contact.Website},

            //Atmosphere
            {"price_level", Atmosphere.PriceLevel},
            {"rating", Atmosphere.Rating},
            {"review", Atmosphere.Review},
            {"user_ratings_total", Atmosphere.UserRatingsTotal},
        };

        private readonly string _field;
        private readonly string _uriEscapeDataString;

        public Field(string field)
        {
            _field = field;

            _uriEscapeDataString = Uri.EscapeDataString(_field);
        }

        public string Value()
        {
            return _field;
        }

        public string GetUriEscapedValue()
        {
            return _uriEscapeDataString;
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
            return _uriEscapeDataString;
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

        public static class Basic
        {
            public static Field AddressComponent = new Field("address_component");
            public static Field AdrAddress = new Field("adr_address");
            public static Field BusinessStatus = new Field("business_status");
            public static Field FormattedAddress = new Field("formatted_address");
            public static Field Geometry = new Field("geometry");
            public static Field Icon = new Field("icon");
            public static Field IconMaskBaseUri = new Field("icon_mask_base_uri");
            public static Field IconBackgroundColor = new Field("icon_background_color");
            public static Field Name = new Field("name");
            public static Field Photo = new Field("photo");
            public static Field PlaceId = new Field("place_id");
            public static Field PlusCode = new Field("plus_code");
            public static Field Type = new Field("type");
            public static Field Url = new Field("url");
            public static Field UtcOffset = new Field("utc_offset");
            public static Field Vicinity = new Field("vicinity");
        }

        public static class Contact
        {
            public static Field FormattedPhoneNumber = new Field("formatted_phone_number");
            public static Field InternationalPhoneNumber = new Field("international_phone_number");
            public static Field OpeningHours = new Field("opening_hours");
            public static Field Website = new Field("website");
        }

        public static class Atmosphere
        {
            public static Field PriceLevel = new Field("price_level");
            public static Field Rating = new Field("rating");
            public static Field Review = new Field("review");
            public static Field UserRatingsTotal = new Field("user_ratings_total");
        }
    }
}
