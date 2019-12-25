/*---------------------------------------------------------------------------------------------
*  Copyright (c) Dolittle. All rights reserved.
*  Licensed under the MIT License. See LICENSE in the project root for license information.
*--------------------------------------------------------------------------------------------*/
import { CommandContext, IFailedCommandOutputter, AuthenticatedCommand } from "@dolittle/tooling.common.commands";
import { IDependencyResolvers, PromptDependency, argumentUserInputType, IsNotEmpty } from "@dolittle/tooling.common.dependencies";
import { ICanOutputMessages, IBusyIndicator } from "@dolittle/tooling.common.utilities";
import { IConnectionChecker, requireInternet} from "@dolittle/tooling.common.packages";
import { QueryCoordinator } from "@dolittle/queries";

import dateformat from 'dateformat';
import { ILoginService, IContexts } from "@dolittle/tooling.common.login";
import { NodesWithinInstallation } from "../../Installations/NodesWithinInstallation";

const name = 'installation';

const description = `Display detailed information of an installation`;

const nameDependencies = [
    new PromptDependency(
        'installation name',
        'name of the installation',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the installation'
    ),
    new PromptDependency(
        'site name',
        'name of the site',
        [new IsNotEmpty()],
        argumentUserInputType,
        'name of the site'
)];

export class DescribeInstallation extends AuthenticatedCommand {

    constructor(private _edgeAPI: string, loginService: ILoginService, contexts: IContexts, private _connectionChecker: IConnectionChecker,
           private _queryCoordinator: QueryCoordinator) {
        super(loginService, contexts, name, description, false, undefined, nameDependencies);
    }
    async onAction(commandContext: CommandContext, dependencyResolvers: IDependencyResolvers, failedCommandOutputter: IFailedCommandOutputter, outputter: ICanOutputMessages, busyIndicator: IBusyIndicator) {
        let context = await dependencyResolvers.resolve({}, this.dependencies);
        let installationName: any = context[nameDependencies[0].name];
        let siteName: any = context[nameDependencies[1].name];
        await requireInternet(this._connectionChecker, busyIndicator);
        QueryCoordinator.apiBaseUrl = this._edgeAPI;
        let commandResult = await this._queryCoordinator.execute(new NodesWithinInstallation(installationName, siteName));
        let formatted: any[] = commandResult.items.map((location: any) => ({
                'Name': location.name,
        }));
        outputter.table(formatted);
    }
}
