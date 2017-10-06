import { Injectable } from '@angular/core';
import { Http , Headers} from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class SectionsService {

  constructor(
    private http:Http 
  ) { }
  
  getAllSections()
  {
  	return this.http.get('http://localhost:5556/api/Section').map(res => res.json());
  }
  
  addSections(section)
  {
    return this.http.post('http://localhost:5556/api/Section',section).map(res => res.json());
  }

  removeSections(sectionId)
  {
    return this.http.delete('http://localhost:5556/api/Section/'+sectionId).map(res => res.json());
  }

  getAllRacks()
  {
    return this.http.get('http://localhost:5556/api/Rack').map(res => res.json());
  }

  getRack(sectionId)
  {
    return this.http.get('http://localhost:5556/api/Rack/'+sectionId).map(res => res.json());
  }

  addRacks(rack)
  {
    return this.http.post('http://localhost:5556/api/Rack',rack).map(res => res.json());
  }

  removeRacks(rackId)
  {
    return this.http.delete('http://localhost:5556/api/Rack/'+rackId).map(res => res.json());
  }

}
