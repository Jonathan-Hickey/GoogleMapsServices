namespace GoogleMapsServices.Client;

public class Language
{
    private readonly string _languageCode;

    private static readonly Dictionary<string, Language> LanguageLookUp = new Dictionary<string, Language>
    {
        {"af", Afrikaans},
        {"sq", Albanian},
        {"am", Amharic},
        {"ar", Arabic},
        {"hy", Armenian},
        {"az", Azerbaijani},
        {"eu", Basque},
        {"be", Belarusian},
        {"bn", Bengali},
        {"bs", Bosnian},
        {"bg", Bulgarian},
        {"my", Burmese},
        {"ca", Catalan},
        {"zh", Chinese},
        {"zh-CN", ChineseSimplified},
        {"zh-HK", ChineseHongKong},
        {"zh-TW", ChineseTraditional},
        {"hr", Croatian},
        {"cs", Czech},
        {"da", Danish},
        {"nl", Dutch},
        {"en", English},
        {"en-AU", EnglishAustralian},
        {"en-GB", EnglishGreatBritain},
        {"et", Estonian},
        {"fa", Farsi},
        {"fi", Finnish},
        {"fil", Filipino},
        {"fr", French},
        {"fr-CA", FrenchCanada},
        {"gl", Galician},
        {"ka", Georgian},
        {"de", German},
        {"el", Greek},
        {"gu", Gujarati},
        {"iw", Hebrew},
        {"hi", Hindi},
        {"hu", Hungarian},
        {"is", Icelandic},
        {"id", Indonesian},
        {"it", Italian},
        {"ja", Japanese},
        {"kn", Kannada},
        {"kk", Kazakh},
        {"km", Khmer},
        {"ko", Korean},
        {"ky", Kyrgyz},
        {"lo", Lao},
        {"lv", Latvian},
        {"lt", Lithuanian},
        {"mk", Macedonian},
        {"ms", Malay},
        {"ml", Malayalam},
        {"mr", Marathi},
        {"mn", Mongolian},
        {"ne", Nepali},
        {"no", Norwegian},
        {"pl", Polish},
        {"pt", Portuguese},
        {"pt-BR", PortugueseBrazil},
        {"pt-PT", PortuguesePortugal},
        {"pa", Punjabi},
        {"ro", Romanian},
        {"ru", Russian},
        {"sr", Serbian},
        {"si", Sinhalese},
        {"sk", Slovak},
        {"sl", Slovenian},
        {"es", Spanish},
        {"es-419", SpanishLatinAmerica},
        {"sw", Swahili},
        {"sv", Swedish},
        {"ta", Tamil},
        {"te", Telugu},
        {"th", Thai},
        {"tr", Turkish},
        {"uk", Ukrainian},
        {"ur", Urdu},
        {"uz", Uzbek},
        {"vi", Vietnamese},
        {"zu", Zulu},
    };

    private readonly string _languageCodeEscapeDataString;
    private readonly string _languageName;

    public Language(string language)
    {
        _languageCode = language;
        _languageName = language;
        _languageCodeEscapeDataString = Uri.EscapeDataString(_languageCode);
    }

    public string LanguageCode()
    {
        return _languageCode;
    }

    public string LanguageName()
    {
        return _languageName;
    }

    public string LanguageCodeEscapeDataString()
    {
        return _languageCodeEscapeDataString;
    }

    public override int GetHashCode()
    {
        return _languageCode.GetHashCode();
    }

    private static bool Equals(Language? fieldOne, Language? fieldTwo)
    {
        if (fieldOne is null && fieldTwo is null) return true;
        if (fieldOne is null != fieldTwo is null) return false;

        return string.Equals(fieldOne.LanguageCode(), fieldTwo.LanguageCode());
    }

    public override bool Equals(object? obj)
    {
        if (obj is Language field) return Equals(this, field);

        return false;
    }

    public override string ToString()
    {
        return _languageCodeEscapeDataString;
    }

    public static Language? Parse(string? input)
    {
        if (string.IsNullOrEmpty(input)) return null;

        if (TryParse(input, out Language? field))
        {
            return field;
        }

        throw new FieldDoesNotExistException(string.Format("Invalid field value {input}", input));
    }

    public static bool TryParse(string input, out Language? field)
    {
        if (string.IsNullOrEmpty(input))
        {
            field = null;
            return false;
        }

        var key = input.ToLowerInvariant();
        if (LanguageLookUp.ContainsKey(key))
        {
            field = LanguageLookUp[key];
            return true;
        }

        field = null;
        return false;
    }

    public static explicit operator Language?(string? input)
    {
        return Parse(input);
    }

    public static bool operator ==(Language? fieldOne, Language fieldTwo)
    {
        return Equals(fieldOne, fieldTwo);
    }

    public static bool operator !=(Language? fieldOne, Language fieldTwo)
    {
        return !Equals(fieldOne, fieldTwo);
    }

    public static Language Afrikaans = new Language("af");
    public static Language Albanian = new Language("sq");
    public static Language Amharic = new Language("am");
    public static Language Arabic = new Language("ar");
    public static Language Armenian = new Language("hy");
    public static Language Azerbaijani = new Language("az");
    public static Language Basque = new Language("eu");
    public static Language Belarusian = new Language("be");
    public static Language Bengali = new Language("bn");
    public static Language Bosnian = new Language("bs");
    public static Language Bulgarian = new Language("bg");
    public static Language Burmese = new Language("my");
    public static Language Catalan = new Language("ca");
    public static Language Chinese = new Language("zh");
    public static Language ChineseSimplified = new Language("zh-CN");
    public static Language ChineseHongKong = new Language("zh-HK");
    public static Language ChineseTraditional = new Language("zh-TW");
    public static Language Croatian = new Language("hr");
    public static Language Czech = new Language("cs");
    public static Language Danish = new Language("da");
    public static Language Dutch = new Language("nl");
    public static Language English = new Language("en");
    public static Language EnglishAustralian = new Language("en-AU");
    public static Language EnglishGreatBritain = new Language("en-GB");
    public static Language Estonian = new Language("et");
    public static Language Farsi = new Language("fa");
    public static Language Finnish = new Language("fi");
    public static Language Filipino = new Language("fil");
    public static Language French = new Language("fr");
    public static Language FrenchCanada = new Language("fr-CA");
    public static Language Galician = new Language("gl");
    public static Language Georgian = new Language("ka");
    public static Language German = new Language("de");
    public static Language Greek = new Language("el");
    public static Language Gujarati = new Language("gu");
    public static Language Hebrew = new Language("iw");
    public static Language Hindi = new Language("hi");
    public static Language Hungarian = new Language("hu");
    public static Language Icelandic = new Language("is");
    public static Language Indonesian = new Language("id");
    public static Language Italian = new Language("it");
    public static Language Japanese = new Language("ja");
    public static Language Kannada = new Language("kn");
    public static Language Kazakh = new Language("kk");
    public static Language Khmer = new Language("km");
    public static Language Korean = new Language("ko");
    public static Language Kyrgyz = new Language("ky");
    public static Language Lao = new Language("lo");
    public static Language Latvian = new Language("lv");
    public static Language Lithuanian = new Language("lt");
    public static Language Macedonian = new Language("mk");
    public static Language Malay = new Language("ms");
    public static Language Malayalam = new Language("ml");
    public static Language Marathi = new Language("mr");
    public static Language Mongolian = new Language("mn");
    public static Language Nepali = new Language("ne");
    public static Language Norwegian = new Language("no");
    public static Language Polish = new Language("pl");
    public static Language Portuguese = new Language("pt");
    public static Language PortugueseBrazil = new Language("pt-BR");
    public static Language PortuguesePortugal = new Language("pt-PT");
    public static Language Punjabi = new Language("pa");
    public static Language Romanian = new Language("ro");
    public static Language Russian = new Language("ru");
    public static Language Serbian = new Language("sr");
    public static Language Sinhalese = new Language("si");
    public static Language Slovak = new Language("sk");
    public static Language Slovenian = new Language("sl");
    public static Language Spanish = new Language("es");
    public static Language SpanishLatinAmerica = new Language("es-419");
    public static Language Swahili = new Language("sw");
    public static Language Swedish = new Language("sv");
    public static Language Tamil = new Language("ta");
    public static Language Telugu = new Language("te");
    public static Language Thai = new Language("th");
    public static Language Turkish = new Language("tr");
    public static Language Ukrainian = new Language("uk");
    public static Language Urdu = new Language("ur");
    public static Language Uzbek = new Language("uz");
    public static Language Vietnamese = new Language("vi");
    public static Language Zulu = new Language("zu");
}