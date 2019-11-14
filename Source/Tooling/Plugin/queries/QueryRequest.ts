/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
import { Query, Guid } from '../internal';

 /**
  * Represents a request for issuing a {Query}
  */
export class QueryRequest {

    correlationId: any;
    nameOfQuery: any;
    generatedFrom: any;
    parameters: any;

    /**
     * Initializes a new instance of {QueryRequest}
     * @param {string} nameOfQuery 
     * @param {string} generatedFrom 
     * @param {*} parameters 
     */
    constructor(nameOfQuery: string, generatedFrom: string, parameters: any) {
        this.correlationId = Guid.create();
        this.nameOfQuery = nameOfQuery;
        this.generatedFrom = generatedFrom;
        this.parameters = parameters;
    }

    /**
     * Creates a {QueryRequest} from a {Query}
     * @param {Query} query 
     */
    static createFrom(query: Query) {
        let nameOfQuery: string = query.nameOfQuery;
        let generatedFrom: string = query.generatedFrom;
        delete query.nameOfQuery;
        delete query.generatedFrom;
        var request: QueryRequest = new QueryRequest(nameOfQuery, generatedFrom, query);
        return request;
    }

}