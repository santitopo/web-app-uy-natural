import { ImportParameter } from './ImportParameter';

export class LodgingImporter {
    parameters: ImportParameter[];
    dllName: string;
    importerName: string;
    
    constructor(DllName: string, ImporterName: string, Parameters: ImportParameter[]) {
      this.dllName = DllName;
      this.importerName = ImporterName;
      this.parameters = Parameters;
  }

}
