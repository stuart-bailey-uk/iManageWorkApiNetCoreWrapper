﻿using Xunit;

namespace WorkspaceWrapper.Comms.Tests
{
    public class DataCollectionBuilderTests
    {
        [Fact]
        public void DeserializeIntoCollectionBuilder()
        {
            //assign

            const string data = @"{
                                    ""data"": {
                                        ""results"": [
                                            {
                                                ""id"": ""Live!6136942.1""
                                            },
                                            {
                                                ""id"": ""Live!6136931.1""
                                            }
                                        ]
                                    }
                                }";



        }

    }
}
