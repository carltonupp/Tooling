﻿// Copyright 2018 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Linq;

namespace Steeltoe.Tooling.Cli
{
    public static class Environments
    {
        private static SortedDictionary<string, IEnvironment> environments = new SortedDictionary<string, IEnvironment>
        {
            {CloudFoundry.CloudFoundryEnvironment.Name,
            new CloudFoundry.CloudFoundryEnvironment()}
        };


        public static IEnumerable<string> GetNames()
        {
            return environments.Keys.ToList();
        }

        public static IEnvironment ForName(string name)
        {
            try
            {
                return environments[name];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }
    }
}