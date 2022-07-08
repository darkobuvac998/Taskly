import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { BoardCardComponent } from './boards/board-card/board-card.component';
import { SharedModule } from './shared/shared.module';
import { TaskComponent } from './tasks/task/task.component';
import { BoardsComponent } from './boards/boards.component';
import { ReactiveFormsModule } from '@angular/forms';
import { StoreModule } from '@ngrx/store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { appReducer } from './store/app.reducer';
import { EffectsModule } from '@ngrx/effects';
import { BoardEffects } from './boards/store/board.effects';
import { environment } from 'src/environments/environment';
import { CodebooksEffects } from './shared/codebook/store/codebook.effects';

@NgModule({
  declarations: [
    AppComponent,
    BoardsComponent,
    BoardCardComponent,
    TaskComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    SharedModule,
    ReactiveFormsModule,
    StoreModule.forRoot(appReducer),
    StoreDevtoolsModule.instrument({
      logOnly: environment.production,
    }),
    EffectsModule.forRoot([BoardEffects, CodebooksEffects]),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
