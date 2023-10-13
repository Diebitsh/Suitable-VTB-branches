export abstract class BaseHttpService {
    abstract apiPath: string;

    getBaseApiPath() {
        return `http://localhost:5074/api/${this.apiPath}`
    }
}