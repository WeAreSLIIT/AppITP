import { TASK4Page } from './app.po';

describe('task4 App', function() {
  let page: TASK4Page;

  beforeEach(() => {
    page = new TASK4Page();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
