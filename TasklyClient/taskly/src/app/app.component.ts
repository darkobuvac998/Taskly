import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ParticlesConfig } from './particlesConfig';
declare let particlesJS: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {

  ngOnInit(): void {
    particlesJS('particles-js', ParticlesConfig, () => {});
  }
}
