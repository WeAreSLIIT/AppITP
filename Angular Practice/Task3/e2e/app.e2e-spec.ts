import { Task3Page } from './app.po';

describe('task3 App', function() {
  let page: Task3Page;

  beforeEach(() => {
    page = new Task3Page();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
