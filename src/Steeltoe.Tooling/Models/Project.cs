// Copyright 2020 the original author or authors.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Steeltoe.Tooling.Models
{
    /// <summary>
    /// A model of a DotNet project.
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Project name.
        /// </summary>
        [YamlMember(Alias = "name")]
        public string Name
        {
            get => _name;
            set => _name = value.ToLower();
        }

        private string _name;

        /// <summary>
        /// Project file path.
        /// </summary>
        [YamlMember(Alias = "file")]
        public string File { get; set; }

        /// <summary>
        /// Project framework.
        /// </summary>
        [YamlMember(Alias = "framework")]
        public string Framework { get; set; }

        /// <summary>
        /// Docker image.
        /// </summary>
        [YamlMember(Alias = "image")]
        public string Image { get; set; }

        /// <summary>
        /// Network ports.
        /// </summary>
        [YamlMember(Alias = "protocols")]
        public List<Protocol> Protocols { get; set; }

        /// <summary>
        /// Project service dependencies to be deployed.
        /// </summary>
        [YamlMember(Alias = "services")]
        public List<Service> Services { get; set; }
    }
}
