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




SmartFormat
-----------
There seem to be multiple packages for SmartFormat in the NuGet feed.
There is 'SmartFormat' package, which is the core package,
and there is 'SmartFormat.NET', which contains all extensions.

For now, I only referenced SmartFormat, ie the core, and I'll see what happens...




=========
API Ideas
=========


Of <T>
------
So, AspNetCore uses an IStringLocalizer, IHtmlLocalizer and a IViewLocalizer.
All of them take an optional 'of T' parameter.
The T parameter points to a tagging class that is used to get a subset of translations.

We could use the T to set an attribute for prefixing/namespacing the translations. 
Like [TranslationNamepace("frontend.ordering")]. If IStringLocalizer<T> is used, all
keys get prefixed by this namespace. Like IStringLocalizer<T>.Localize("shipping_address")
becomes "frontend.ordering.shipping_address".


Parameters
----------
To implement the interfaces from AspNetCore Localization (IStringLocalizer etc), we could
merge all parameters as an anonymous object to pass to the SmartFormat one. Or does SmartFormat
also accept 'params object[] values'? Let's find out.


String/html
-----------
There is an IStringLocalizer and an IHtmlLocalizer. Let's find out what the EXACT difference
is between those two.
We might be able to warn/throw when using the plain IStringLocalizer for translations with
possible dangerous characters like '<' and such. If the user knows the risk, he should pass
in an surpress flag or something.
Or, when sourcing the translations, we could detect dangerous characters and throw as soon
as possible. The user could tell at 'source-time' that the string contains HTML or that he
knows the string is dangerous, to surpress warnings at startup/source-time.

There is also IViewLocalizer. Find out how thats different from Localizer<TViewModel>.
Appearently, the IViewLocalizer gets its resources by the filepath of the view.


Sourcing
--------
When setting up DI, the user can add translation sources. This could be a database source
or a resx. Or even other sources.
The order of adding them does matter, because translations added later will overwrite the
previous. Meaning you can override translations.
The moment of fetching from source is yet to be determined.
