﻿using ProtoBuf.Grpc.Configuration;

namespace EnchantedCoder.Blazor.Grpc.Core;

public class ProtoBufServiceBinder : ServiceBinder
{
	public override bool IsServiceContract(Type contractType, out string name)
	{
		name = GetDefaultName(contractType);
		return true;
	}
}
