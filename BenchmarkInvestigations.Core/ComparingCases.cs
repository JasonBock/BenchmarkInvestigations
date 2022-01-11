using BenchmarkDotNet.Attributes;
using System.ComponentModel;

namespace BenchmarkInvestigations.Core;

[MemoryDiagnoser]
public class ComparingCases
{
	private readonly static Log log = new(true, false, false, true, true);
	private readonly static IDictionary<LogLevel, Func<Log, bool>> isEnabledFunctions =
		new Dictionary<LogLevel, Func<Log, bool>>()
		{
			{ LogLevel.Trace, log => log.IsDebugEnabled },
			{ LogLevel.Debug, log => log.IsDebugEnabled },
			{ LogLevel.Warning, log => log.IsWarnEnabled },
			{ LogLevel.Error, log => log.IsErrorEnabled },
			{ LogLevel.Information, log => log.IsInfoEnabled },
			{ LogLevel.Critical, log => log.IsFatalEnabled }
		};

	[Benchmark]
	public bool IsEnabledUsingDictionary() =>
		ComparingCases.isEnabledFunctions[this.Level](ComparingCases.log);

	[Benchmark(Baseline = true)]
	public bool IsEnabledUsingSwitch()
	{
		switch (this.Level)
		{
			case LogLevel.Trace:
			case LogLevel.Debug:
				return ComparingCases.log.IsDebugEnabled;
			case LogLevel.Warning:
				return ComparingCases.log.IsWarnEnabled;
			case LogLevel.Error:
				return ComparingCases.log.IsErrorEnabled;
			case LogLevel.Information:
				return ComparingCases.log.IsInfoEnabled;
			case LogLevel.Critical:
				return ComparingCases.log.IsFatalEnabled;
			default:
				throw new InvalidEnumArgumentException();
		}
	}

	[Benchmark]
	public bool IsEnabledUsingSwitchExpression() => 
		this.Level switch
		{
			LogLevel.Trace or LogLevel.Debug => ComparingCases.log.IsDebugEnabled,
			LogLevel.Warning => ComparingCases.log.IsWarnEnabled,
			LogLevel.Error => ComparingCases.log.IsErrorEnabled,
			LogLevel.Information => ComparingCases.log.IsInfoEnabled,
			LogLevel.Critical => ComparingCases.log.IsFatalEnabled,
			_ => throw new InvalidEnumArgumentException(),
		};

	[Benchmark]
	public bool IsEnabledUsingIf()
	{
		if (this.Level == LogLevel.Trace || this.Level == LogLevel.Debug)
		{
			return ComparingCases.log.IsDebugEnabled;
		}
		else if (this.Level == LogLevel.Warning)
		{
			return ComparingCases.log.IsWarnEnabled;
		}
		else if (this.Level == LogLevel.Error)
		{
			return ComparingCases.log.IsErrorEnabled;
		}
		else if (this.Level == LogLevel.Information)
		{
			return ComparingCases.log.IsInfoEnabled;
		}
		else if (this.Level == LogLevel.Critical)
		{
			return ComparingCases.log.IsFatalEnabled;
		}
		else
		{
			throw new InvalidEnumArgumentException();
		}
	}

	[ParamsAllValues]
	public LogLevel Level { get; set; }
}

public sealed class Log
{
	public Log(bool isDebugEnabled, bool isInfoEnabled, bool isWarnEnabled, bool isErrorEnabled, bool isFatalEnabled) =>
		(this.IsDebugEnabled, this.IsWarnEnabled, this.IsErrorEnabled, this.IsInfoEnabled, this.IsFatalEnabled) =
			(isDebugEnabled, isWarnEnabled, isErrorEnabled, isInfoEnabled, isFatalEnabled);

	public bool IsDebugEnabled { get; }
	public bool IsWarnEnabled { get; }
	public bool IsErrorEnabled { get; }
	public bool IsInfoEnabled { get; }
	public bool IsFatalEnabled { get; }
}

public enum LogLevel { Trace, Debug, Warning, Error, Information, Critical }