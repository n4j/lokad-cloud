﻿#region Copyright (c) Lokad 2009
// This code is released under the terms of the new BSD licence.
// URL: http://www.lokad.com/
#endregion
using System;
using System.Linq;
using NUnit.Framework;

namespace Lokad.Cloud.Core.Test
{
	[TestFixture]
	public class QueueStorageProviderTests
	{
		private const string QueueName = "tests-queuestorageprovider-mymessage";

		private static Random _rand = new Random();

		[Test]
		public void PutGetDelete()
		{
			var provider = GlobalSetup.Container.Resolve<IQueueStorageProvider>();

			Assert.IsNotNull(provider, "#A00");

			var message = new MyMessage();

			provider.Put(QueueName, new [] {message});
			var retrieved = provider.Get<MyMessage>(QueueName, 1).First();

			Assert.AreEqual(message.MyGuid, retrieved.MyGuid, "#A01");

			provider.Delete(QueueName, new [] { retrieved });
		}

		[Test]
		public void PutGetDeleteOverflowing()
		{
			var provider = GlobalSetup.Container.Resolve<IQueueStorageProvider>();

			Assert.IsNotNull(provider, "#A00");

			// 20k chosen so that it doesn't fit into the queue.
			var message = new MyMessage { MyBuffer = new byte[20000] };

			// fill buffer with random content
			_rand.NextBytes(message.MyBuffer);

			provider.Put(QueueName, new[] { message });
			var retrieved = provider.Get<MyMessage>(QueueName, 1).First();

			Assert.AreEqual(message.MyGuid, retrieved.MyGuid, "#A01");
			Assert.AreEqual(message.MyBuffer.Length, retrieved.MyBuffer.Length, "#A02");

			for (int i = 0; i < message.MyBuffer.Length; i++ )
			{
				Assert.AreEqual(message.MyBuffer[i], retrieved.MyBuffer[i], "#A02-" + i);	
			}

			provider.Delete(QueueName, new[] { retrieved });
		}
	}

	[Serializable]
	public class MyMessage
	{
		public Guid MyGuid { get; private set; }

		public byte[] MyBuffer { get; set; }

		public MyMessage()
		{
			MyGuid = Guid.NewGuid();
		}
	}
}