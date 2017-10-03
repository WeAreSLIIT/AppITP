import { ItpxPage } from './app.po';

describe('itpx App', function() {
  let page: ItpxPage;

  beforeEach(() => {
    page = new ItpxPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
