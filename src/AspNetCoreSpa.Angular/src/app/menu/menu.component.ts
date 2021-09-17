import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  activatedRoute: Router
  constructor(router: Router) {
    this.activatedRoute = router;
  }

  ngOnInit(): void {
  }

}
