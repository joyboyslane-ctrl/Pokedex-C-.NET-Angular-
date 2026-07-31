import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  isGerman = signal<boolean>(true);

  toggle(): void {
    this.isGerman.set(!this.isGerman());
  }
}