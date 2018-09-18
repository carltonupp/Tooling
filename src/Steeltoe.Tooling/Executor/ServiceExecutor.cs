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

namespace Steeltoe.Tooling.Executor
{
    public abstract class ServiceExecutor : IExecutor
    {
        protected string Name { get; }

        public ServiceExecutor(string name)
        {
            Name = name;
        }

        public virtual void Execute(Context context)
        {
            if (!context.ServiceManager.HasService(Name))
            {
                throw new ServiceNotFoundException(Name);
            }
        }
    }
}