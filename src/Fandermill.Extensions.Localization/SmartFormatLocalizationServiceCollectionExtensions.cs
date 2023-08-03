using Microsoft.Extensions.DependencyInjection;
using SmartFormat;

namespace Fandermill.Extensions.Localization;

public static class SmartFormatLocalizationServiceCollectionExtensions
{
    public static void AddSmartFormatLocalization(this IServiceCollection services)
    {
        // Hmm,
        // https://github.com/axuno/SmartFormat/wiki/Localization-_-LocalizationFormatter
        // We might use the localization formatter directly from SmartFormat.

        //Smart.Default.Settings.Localization.LocalizationProvider = new ...



        // var translationKey = "some.translation.key";
        // var cultureInfo = new CUltureInfo("nl-NL");
        // Smart.Format(cultureInfo, "{:L:" + translationKey +"}");



        // We might need to implement a fallback system?
        // To let "en-US" fallback to "en-GB". And if not any, to "nl-NL".
        // Like matching language, but mismatch region.



        // And merge / adapt with
        // https://github.com/dotnet/aspnetcore/blob/main/src/Localization/Localization/src/LocalizationServiceCollectionExtensions.cs
    }
}
