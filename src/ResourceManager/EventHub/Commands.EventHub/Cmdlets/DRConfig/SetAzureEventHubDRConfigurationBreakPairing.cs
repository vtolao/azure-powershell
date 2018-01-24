﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.EventHub.Models;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.EventHub.Commands.GeoDR
{
    /// <summary>
    /// 'Set-AzureRmEventHubDRConfigurationBreakPairing' Cmdlet disables the Disaster Recovery and stops replicating changes from primary to secondary namespaces
    /// </summary>
    [Cmdlet(VerbsCommon.Set, EventhubDRConfigurationBreakPairingVerb, SupportsShouldProcess = true), OutputType(typeof(void))]
    public class SetAzureEventHubDRConfigurationBreakPairing : AzureEventHubsCmdletBase
    {
        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 0,
            HelpMessage = "Resource Group Name.")]
        [ValidateNotNullOrEmpty]
         public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 1,
            HelpMessage = "Namespace Name - Primary Namespace")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasNamespaceName)]
        public string Namespace { get; set; }

        [Parameter(Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            Position = 2,
            HelpMessage = "DR Configuration Name.")]
        [ValidateNotNullOrEmpty]
        [Alias(AliasAliasName)]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            //Set Break Pairing
            if (ShouldProcess(target: Name, action: string.Format(Resources.DRBreakPairing, Name, Namespace)))
            {
                Client.SetEventHubDRConfigurationBreakPairing(ResourceGroupName, Namespace, Name);
            }

        }
    }
}
