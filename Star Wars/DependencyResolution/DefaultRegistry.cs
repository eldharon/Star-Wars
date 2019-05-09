// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Star_Wars.DependencyResolution {
    using Star_Wars.DAL;
    using Star_Wars.Model;
    using Star_Wars.Repository;
    using Star_Wars.Service;
    using StructureMap.Configuration.DSL;
    using StructureMap.Graph;
	
    public class DefaultRegistry : Registry {
        #region Constructors and Destructors

        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            //Injecting Repository layer
            For<IRepository<Character>>().Use<Repository<Character>>();
            For<IRepository<Episode>>().Use<Repository<Episode>>();

            //Injecting Service layer
            For<IService<Character>>().Use<Service<Character>>();
            For<IService<Episode>>().Use<Service<Episode>>();

            //Injecting context
            var context = new StarWarsContext();
            For<StarWarsContext>().Use(context);

        }



        #endregion
    }
}