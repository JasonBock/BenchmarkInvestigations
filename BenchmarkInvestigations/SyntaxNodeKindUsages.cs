using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BenchmarkInvestigations;

[MemoryDiagnoser]
public class SyntaxNodeKindUsages
{
	private SyntaxNode? node;

	[GlobalSetup]
	public void GlobalSetup()
	{
		var unit = SyntaxFactory.ParseCompilationUnit("public class Data { }");
		this.node = unit.DescendantNodes(_ => true).OfType<ClassDeclarationSyntax>().Single();
	}

	[Benchmark(Baseline = true)]
	public bool CheckKindUsingIsKind() => this.node!.IsKind(SyntaxKind.ClassDeclaration);

	[Benchmark]
	public bool CheckKindUsingKind() => this.node!.Kind() == SyntaxKind.ClassDeclaration;

	[Benchmark]
	public bool CheckKindUsingRawKind() => this.node!.RawKind == (int)SyntaxKind.ClassDeclaration;
}