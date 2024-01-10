import { defineStore } from 'pinia';

interface UserSettings {
    language: string;
    flags: string[];
}

export const useSettingsStore = defineStore('settings', {
    state: () => ({
      language: 'fr',
      blacklistFlags: ['nsfw', 'racist', 'sexist', 'explicit', 'religious', 'political'],
    }),
    actions: {
        setLanguage(language: string) {
            this.language = language;
            console.log(this.language);
        },
        setBlacklistFlags(flags: string[]) {
            this.blacklistFlags = flags;
            console.log(this.blacklistFlags);
        },
    },
    persist: {
        storage: persistedState.localStorage,
      },
  },
);
