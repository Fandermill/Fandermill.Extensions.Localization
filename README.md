# Fandermill.Extensions.Localization

The plan
--------

It looks like SmartFormat is exactly what we need:
https://github.com/axuno/SmartFormat

And integrate this SmartFormat and syntaxes into implementations of IStringLocalizer and IHtmlLocalizer from Microsoft. Or sort of.
We cannot change the signatures ofcourse.

Preferred signature for IStringLocalizer

```csharp
string Localize(string key, object? params = null);
string Localize(CultureInfo cultureInfo, string key, object? params = null);
```

So we can invoke:
```csharp
localizer.Localize("some.key.with.namespace", new { SomeParameter = "Text" });
```

Would be nice to 'just work' with the AspNetCore localization stuff. With resource files (resx) n all, ya know.

Sourcing
--------
We also need to have some kind of translation source. Would be cool to work independently from the above. But also with AspNetCore localization. There is already an implementation from Damien Bowden (https://github.com/damienbod/AspNetCoreLocalization)


Useful link: https://www.ezzylearning.net/tutorial/asp-net-core-localization-from-database
(also see comments and previous tuts)
