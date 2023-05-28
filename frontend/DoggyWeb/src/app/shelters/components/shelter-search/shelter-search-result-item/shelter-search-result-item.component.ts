import { AfterViewInit, Component, Input, OnInit } from '@angular/core';
import { ShelterSearchResultItem } from 'src/app/shelters/models';

@Component({
  selector: 'app-shelter-search-result-item',
  templateUrl: './shelter-search-result-item.component.html',
  styleUrls: ['./shelter-search-result-item.component.css']
})
export class ShelterSearchResultItemComponent implements OnInit {

  constructor() { }

  @Input() model!: ShelterSearchResultItem;

  public ngOnInit(): void {
  }
}
