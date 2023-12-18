import type { Config } from 'tailwindcss'
import defaultTheme from 'tailwindcss/defaultTheme'

export default <Partial<Config>>{
  theme: {
    extend: {
      colors: {
        green: {
          50: '#f0fdfb',
          100: '#cdfaf5',
          200: '#9cf3ec',
          300: '#62e6e0',
          400: '#32cfcd',
          500: '#19b3b3',
          600: '#118e90',
          700: '#127073',
          800: '#13595c',
          900: '#154a4c',
          950: '#062F33'
        },
        light: {
          50: '#7A9597',
          100: '#7A9597',
          200: '#7A9597',
          300: '#7A9597',
          400: '#7A9597',
          500: '#7A9597',
          600: '#7A9597',
          700: '#7A9597',
          800: '#7A9597',
          900: '#7A9597',
          950: '#7A9597'
        }
      }
    }
  }
}
