﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Framework.Logging;

namespace Microsoft.AspNet.Mvc.Logging
{
    /// <summary>
    /// Represents the state of <see cref="DefaultActionSelector.SelectAsync(AspNet.Routing.RouteContext)"/>.
    /// </summary>
    public class DefaultActionSelectorSelectAsyncValues : LoggerStructureBase
    {
        /// <summary>
        /// The name of the state.
        /// </summary>
        public string Name
        {
            get
            {
                return "DefaultActionSelector.SelectAsync";
            }
        }

        /// <summary>
        /// The list of actions that matched all their route constraints, if any.
        /// </summary>
        public IEnumerable<ActionDescriptorValues> ActionsMatchingRouteConstraints { get; set; }

        /// <summary>
        /// The list of actions that matched all their route constraints, and action constraints, if any.
        /// </summary>
        public IEnumerable<ActionDescriptorValues> ActionsMatchingActionConstraints { get; set; }

        /// <summary>
        /// The list of actions that are the best matches. These match all constraints and any additional criteria
        /// for disambiguation.
        /// </summary>
        public IEnumerable<ActionDescriptorValues> FinalMatches { get; set; }

        /// <summary>
        /// The selected action. Will be null if no matches are found or more than one match is found.
        /// </summary>
        public ActionDescriptorValues SelectedAction { get; set; }

        /// <summary>
        /// A summary of the data for display.
        /// </summary>
        public string Summary
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendLine(Name);
                builder.Append("\tActions matching route constraints: ");
                StringBuilderHelpers.Append(builder, ActionsMatchingRouteConstraints, Formatter);
                builder.AppendLine();
                builder.Append("\tActions matching action constraints: ");
                StringBuilderHelpers.Append(builder, ActionsMatchingActionConstraints, Formatter);
                builder.AppendLine();
                builder.Append("\tFinal Matches: ");
                StringBuilderHelpers.Append(builder, FinalMatches, Formatter);
                builder.AppendLine();
                builder.Append("\tSelected action: ");
                builder.Append(Formatter(SelectedAction));
                return builder.ToString();
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Summary;
        }

        private string Formatter(ActionDescriptorValues descriptor)
        {
            return descriptor != null ? descriptor.Name : "No action selected";
        }

        public override string Format()
        {
            return LogFormatter.FormatStructure(this);
        }
    }
}