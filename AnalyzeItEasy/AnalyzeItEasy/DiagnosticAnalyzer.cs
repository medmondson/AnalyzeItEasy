using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace AnalyzeItEasy
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class AnalyzeItEasyAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "AnalyzeItEasy";

        // You can change these strings in the Resources.resx file. If you do not want your analyzer to be localize-able, you can use regular strings for Title and MessageFormat.
        // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Localizing%20Analyzers.md for more on localization
        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Naming";

        private static DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get { return ImmutableArray.Create(Rule); } }

        public override void Initialize(AnalysisContext context)
        {
            // TODO: Consider registering other actions that act on syntax instead of or in addition to symbols
            // See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/Analyzer%20Actions%20Semantics.md for more information
            context.RegisterSyntaxNodeAction(AnalyzeSymbol, SyntaxKind.InvocationExpression);
        }

        private static void AnalyzeSymbol(SyntaxNodeAnalysisContext syntaxNodeAnalysisContext)
        {
            //Need an InvocationExpression
            SymbolInfo symbolInfo =  syntaxNodeAnalysisContext.SemanticModel.GetSymbolInfo(syntaxNodeAnalysisContext.Node);

           //Exclude interface here

            ImmutableArray<ITypeSymbol> typeArguments = ((IMethodSymbol)symbolInfo.Symbol).TypeArguments;

            bool containsVirtualMember = false;

            foreach (ITypeSymbol typeArgument in typeArguments)
            {
                containsVirtualMember = typeArgument.GetMembers().Any(m => m.IsVirtual);
                //Analyze each for members that are non-virtual
            }

            if (!containsVirtualMember)
            {
                Location location = syntaxNodeAnalysisContext.Node.GetLocation();

                Diagnostic diagnostic = Diagnostic.Create(Rule, location, ((IMethodSymbol)symbolInfo.Symbol).ReceiverType.Name);
                syntaxNodeAnalysisContext.ReportDiagnostic(diagnostic);

            }

        }
    }
}
