#! "netcoreapp2.0"
#load "CSharpCodeFileWriter.csx"
#load "COllectionTypes.csx"

var stringBuilder = new StringBuilder();
var writer = new CSharpCodeFileWriter(new StringWriter(stringBuilder));

const string itemType = "string";
var supportedCollectionTypes = new CollectionTypeInfo[]
{
      new ArrayInfo(itemType),
      new ListInfo(itemType),
      new AbstractReadOnlyListInfo(itemType),
      new AbstractListInfo(itemType),
      new ObservableCollectionInfo(itemType),
      new CollectionInfo(itemType),
      new EnumerableInfo(itemType)
};


writer.IncludeNamespace(Namespaces.System)
      .IncludeNamespace(Namespaces.SystemCollectionsGeneric)
      .IncludeNamespace(Namespaces.SystemRuntimeCompilerServices)
      .IncludeNamespace(Namespaces.SystemCollectionsObjectModel)
      .WriteEmptyLine()
      .OpenNamespace(Namespaces.LightGuardClauses)
      .OpenPublicStaticPartialClass("UriAssertions");

foreach (var info in supportedCollectionTypes)
{
    writer.WriteAggressiveInliningAttribute()
          .OpenMember($"public static Uri MustHaveOneSchemeOf(this Uri parameter, {info.CollectionType} schemes, string parameterName = null, string message = null)")
          .WriteLine("parameter.MustBeAbsoluteUri(parameterName);");

    info.OpenLoop(writer, "scheme", "schemes")
        .WriteLine("if (string.Equals(parameter.Scheme, scheme, StringComparison.OrdinalIgnoreCase))")
        .IncreaseIndentation()
        .WriteLine("return parameter;")
        .DecreaseIndentation()
        .CloseScope()
        .WriteEmptyLine()
        .WriteLine("Throw.UriMustHaveOneSchemeOf(parameter, schemes, paramterName, message);")
        .WriteLine("return null;")
        .CloseScope()
        .WriteEmptyLine();
}
      
writer.CloseRemainingScopes(); 

Console.WriteLine(stringBuilder.ToString())