using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",          
    Target = "CodeTiger.Collections.Generic",
    Justification = "This namespace mirrors the existing System.Collections.Generic namespace.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
    Target = "CodeTiger.Threading",
    Justification = "This namespace mirrors te existing System.Threading namespace.")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
    Target = "CodeTiger.Threading.Tasks",
    Justification = "This namespace mirrors the existing System.Threading.Tasks namespace.")]
[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly",
    Justification = "The AssemblyInformationalVersionAttribute does not require a parsable version number.")]
