import { Component, OnInit } from '@angular/core';
import { ShelterSearchResultItem } from 'src/app/shelters/models';

@Component({
  selector: 'app-shelter-search-result',
  templateUrl: './shelter-search-result.component.html',
  styleUrls: ['./shelter-search-result.component.css']
})
export class ShelterSearchResultComponent implements OnInit {

  constructor() { }

  public searchResult: ShelterSearchResultItem[] = [
    {
      name: 'First Med Shelter',
      address: 'Kharkiv, Akademika Pavlova, 17/9',
      description: 'Dogs only. Vet-clinic and shelter from 2012.',
      rating: 4
    }
  ];

  ngOnInit(): void {
  }

}
