// import original module declarations
import 'styled-components';

// and extend them!
declare module 'styled-components' {
  export interface DefaultTheme {
    colors: {
      primary: string;
      secondary: string;
      tertiary: string;
      quaternary: string;
      quinary: string;
      success: string;
      successHighlight: string;
      error: string;
      errorHighlight: string;
      typography: string;
      white: string;
    };
    breakpoints: {
      sm: string;
      md: string;
      lg: string;
    };
  }
}
