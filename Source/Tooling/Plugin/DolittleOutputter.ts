import { ICanOutputMessages } from "@dolittle/tooling.common.utilities";
import chalk from 'chalk';

export class DolittleOutputter implements ICanOutputMessages {

    /*
    The JSON coming from Dolittle is formatted so we can parse it for different messages
    */
    printPretty(json: any, successString: string, failString: string) {
        if (json.success) {
            console.log(successString);
        } else if (json.hasBrokenRules) {
            this.error('Command failed:')
            json.brokenRules.forEach((brokenRule: any) => {
                this.error(`Rules broken: ${brokenRule.rule}`);
                brokenRule.causes.forEach((cause: any) => {
                    this.error(`Cause: ${cause.title}`);
                });
            });
        } else {
            this.error('Command failed:')
            this.error(failString);
            if (json.exception && json.exception.message) {
                // @joel is this useful at all?
                this.error(json.exception.message);
                this.error(json.exception.stackTrace);
            }
        }
    }

    print(...args: any[]) {
        if (args && args.length > 1) {
            const json: any = args[0];
            const successString: string = args[1];
            const failString: string = args[2];
            this.printPretty(json, successString, failString);
        } else {
            console.log(...args);
        }
    }

    /*
    these are copied from the original Outputter
    https://github.com/dolittle-tools/cli/blob/master/Source/Outputter.ts
    */
    warn(...args: any[]) {
        console.warn(...args.map(_ => chalk.yellow(_)));
    }
    
    error(...args: any[]) {
        if (args && args.length > 0) {
            console.error(...args.map(_ => chalk.red(_)));
        }
    }

    table(data: any[]) {
        console.table(data);
    }
}
